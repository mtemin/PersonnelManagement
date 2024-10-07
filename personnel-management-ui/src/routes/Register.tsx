import { Button } from "@/components/ui/button"
import { Input } from './ui/input'

export default function Register() {
  return (
    <section className='w-[25rem] mt-[25%] m-auto'>
      <Input className='mb-4' type="text" placeholder="Name" />
      <Input className='mb-4' type="text" placeholder="Surname" />
      <Input className='mb-4' type="email" placeholder="Email" />
      <Input className='mb-4' type="password" placeholder="Password" />
      <Button className='mx-auto'>
        Register
      </Button>
    </section>

  )
}
