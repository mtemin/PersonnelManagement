import { Button } from "@/components/ui/button"
import { Input } from '@/components/ui/input'

export default function Register() {
  return (
    <section className='w-[25rem] mt-[25vh] translate-y-[-%50] m-auto'>
        <h4 className="text-2xl mb-6">Register</h4>
      <Input className='mb-4' type="text" placeholder="Username" />
      <Input className='mb-4' type="text" placeholder="Name" />
      <Input className='mb-4' type="text" placeholder="Surname" />
      <Input className='mb-4' type="email" placeholder="Email" />
      <Input className='mb-4' type="password" placeholder="Password" />
      <Button className='mb-4 ml-auto'>
        Register
      </Button>
        <p>Go back to&nbsp;<a className="text-link underline" href="/">Homepage</a></p>
    </section>

  )
}
